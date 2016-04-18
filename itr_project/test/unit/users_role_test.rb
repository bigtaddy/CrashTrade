# == Schema Information
#
# Table name: users_roles
#
#  id         :integer          not null, primary key
#  user_id    :integer
#  role_id    :integer
#  created_at :datetime         not null
#  updated_at :datetime         not null
#

require 'test_helper'

class UsersRoleTest < ActiveSupport::TestCase
  # test "the truth" do
  #   assert true
  # end
end
